    public string OpenTextFile()
            {
                OpenFileDialog ofd = new OpenFileDialog();
                Nullable<bool> res = ofd.ShowDialog();
                if(res == true)
                {
                    using(StreamReader sr = new StreamReader(ofd.FileName))
                    {
                      return sr.ReadToEnd();
                    }
                }
                //Here message error
                throw new Exception("Something");
            }
