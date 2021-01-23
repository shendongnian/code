    using (StreamWriter sw = File.CreateText("newfile.csv"))
            {
                for (int i = 0; i < threshhld; i++)
                {
                    //writing two columns right next to eachother 
                    sw.WriteLine(dl[i] + "," + xl[i]);
                     
                }
            }
