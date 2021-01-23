    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    
    namespace StackExchangeSelfMovingExe
    {
        class Program
        {
            static void Main(string[] args)
            {
                // check if we are running in the correct path or not?
                bool DoMoveExe = !IsRunningInDocuments();
                            string runningPath = Directory.GetCurrentDirectory();
                if (DoMoveExe)
                {
                    // if we get here then we are not, copy our app to the right place.
                    string newAppPath = GetDesiredExePath();
                    CopyFolder(runningPath, newAppPath);
                    CreateToDeleteMessage(newAppPath, runningPath); // leave a message so new process can delete the old app path
    
                    // start the application running in the right directory.
                    string newExePath = $"{GetDesiredExePath()}\\{System.AppDomain.CurrentDomain.FriendlyName}";
                    ExecuteExe(newExePath);
    
                    // kill our own process since a new one is now running in the right place.
                    KillMyself();
                }
                else
                {
                    // if we get here then we are running in the right place. check if we need to delete the old exe before we ended up here.
                    string toDeleteMessagePath = $"{runningPath}\\CopiedFromMessage.txt";
                    if (File.Exists(toDeleteMessagePath))
                    {
                        // if the file exists then we have been left a message to tell us to delete a path.
                        string pathToDelete = System.IO.File.ReadAllText(toDeleteMessagePath);
                        // kill any processes still running from the old folder.
                        KillAnyProcessesRunningFromFolder(pathToDelete);
                        Directory.Delete(pathToDelete, true);
                    }
    
                    // remove the message so next time we start, we don't try to delete it again.
                    File.Delete(toDeleteMessagePath);
                }
    
                // do application start here since we are running in the right place.
            }
    
    
    
            static string GetDesiredExePath()
            {
                // this is the directory we want the app running from.
                string userPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                return $"{userPath}\\documents\\MyExe".ToLower();
            }
            static bool IsRunningInDocuments()
            {
                // returns true if we are running from within the root of the desired directory.
                string runningPath = Directory.GetCurrentDirectory();
                return runningPath.StartsWith(GetDesiredExePath());
            }
            
            // this copy method is from http://stackoverflow.com/questions/58744/best-way-to-copy-the-entire-contents-of-a-directory-in-c-sharp
            public static void CopyFolder(string SourcePath, string DestinationPath)
            {
                //Now Create all of the directories
                foreach (string dirPath in Directory.GetDirectories(SourcePath, "*",
                    SearchOption.AllDirectories))
                    Directory.CreateDirectory(DestinationPath + dirPath.Remove(0, SourcePath.Length));
    
                //Copy all the files & Replaces any files with the same name
                foreach (string newPath in Directory.GetFiles(SourcePath, "*.*",
                    SearchOption.AllDirectories))
                    File.Copy(newPath, DestinationPath + newPath.Remove(0, SourcePath.Length), true);
            }
    
            private static void CreateToDeleteMessage(string newPath, string runningPath)
            {
                // simply write a file with the folder we are in now so that this folder can be deleted later.
                using (System.IO.StreamWriter file =
                new System.IO.StreamWriter($"{newPath}\\CopiedFromMessage.txt", true))
                {
                    file.Write(runningPath);
                }
            }
    
            private static void ExecuteExe(string newExePath)
            {
                // launch the process which we just copied into documents.
                System.Diagnostics.Process.Start(newExePath);
            }
    
            private static void KillMyself()
            {
                // this is one way, depending if you are using console, forms, etc you can use more appropriate method to exit gracefully.
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
    
            private static void KillAnyProcessesRunningFromFolder(string pathToDelete)
            {
                // kill any processes still running from the path we are about to delete, just incase they hung, etc.
                var processes = System.Diagnostics.Process.GetProcesses()
                                .Where(p => p.MainModule.FileName.StartsWith(pathToDelete, true, CultureInfo.InvariantCulture));
                foreach (var proc in processes)
                {
                    proc.Kill();
                }
            }
        }
    }
