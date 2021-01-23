        private void CreateProcedure(MvcAppDb context)
        {  
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + @"/Procedures.sql";
            Console.WriteLine(path);
            FileInfo file = new FileInfo(path);
            string script = file.OpenText().ReadToEnd();
            context.Database.ExecuteSqlCommand(script);  
        }
