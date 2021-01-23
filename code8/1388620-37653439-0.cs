    protected void btnSqlfinder_Click(object sender, EventArgs e)  
    {  
        //Defining the path of directory where all files saved  
        string filepath = @ "D:\TPMS\App_Code\";  
        //get the all file names inside the directory  
        string[] files = Directory.GetFiles(filepath);  
        //loop through the files to search file one by one   
        for (int i = 0; i < files.Length; i++)  
        {  
            string sourcefilename = files[i];  
            StreamReader sr = File.OpenText(sourcefilename);  
            string sourceline = "";  
            int lineno = 0;  
            while ((sourceline = sr.ReadLine()) != null)  
            {  
                lineno++;  
                //defining the Keyword for search  
                if (sourceline.Contains("from"))  
                {  
                    //append the result to multiline text box  
                    TxtResult.Text += sourcefilename + lineno.ToString() + sourceline + System.Environment.NewLine;  
                }  
                if (sourceline.Contains("into"))  
                {  
                    TxtResult.Text += sourcefilename + lineno.ToString() + sourceline + System.Environment.NewLine;  
                }  
                if (sourceline.Contains("set"))  
                {  
                    TxtResult.Text += sourcefilename + lineno.ToString() + sourceline + System.Environment.NewLine;  
                }  
                if (sourceline.Contains("delete"))  
                {  
                    TxtResult.Text += sourcefilename + lineno.ToString() + sourceline + System.Environment.NewLine;  
                }  
            }  
        }  
    }  
