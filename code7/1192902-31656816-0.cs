    public void Main()
    		{
    			// TODO: Add your code here
                string directoryPath = Dts.Variables["User::DestinationFilePath"].Value.ToString();
                string[] oldFiles = System.IO.Directory.GetFiles(directoryPath, Dts.Variables["User::VarFileName"].Value.ToString());
                foreach (string currFile in oldFiles)
                {
                    FileInfo currFileInfo = new FileInfo(currFile);
                    currFileInfo.Delete();
    
                }
    			Dts.TaskResult = (int)ScriptResults.Success;
    		}
