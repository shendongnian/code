    public class MyFiles
        {
            public string Name { get; set; }
            public long Size { get; set; }
            public string Path { get; set;}
        }
        public class MyWorkClass
        {
            private void InputFiles()
            {
                var files = new List<MyFiles>();
                var file = new MyFiles { Name = "File1.dll", Size = 1215454 };
                files.Add(file);
                file = new MyFiles { Name = "File2.dll", Size = 15544 };
                files.Add(file);
                ProcessFile(files);
            }
            private void ProcessFile(List<MyFiles> files)
            {
                foreach (MyFiles file in files)
                {
                    var name = file.Name;
                    var size = file.Size;
                    //Do other things
                }
            }
        }
