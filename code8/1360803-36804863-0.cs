    private void button1_Click(object sender, EventArgs e)
    {
            string[] ls = Directory.GetFiles(@"C:\Users\mchotu\Desktop\Sample data", "*.txt", SearchOption.AllDirectories);
    
            foreach(string file in ls)
            {
                using (StreamReader sr = new StreamReader(file))
                {
                    using (var db = new DataClasses1DataContext())
                    {
                        string s;
                        int line = 0;
    
                        while((s=sr.ReadLine()) !=null)
                        {
                            db.textFilesCompletes.InsertOnSubmit(new textFilesComplete() { fileNameone = file ,text = s ,Linenumber = line });
                           
                        }
    
                        db.SubmitChanges();
                    }
                }                
            }
    		// dont know what your doing here?
            this.textFilesCompleteTableAdapter.Fill(this.database1DataSet.textFilesComplete);
    } 
