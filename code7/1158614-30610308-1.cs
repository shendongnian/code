    static void Main()
        {
            ListOfVariablesToSave model = new ListOfVariablesToSave();
            List<int> controlDB = new List<int> { 1, 2, 3 };
            List<int> interacDB = new List<int> { 21, 22, 23 };
            model.controlDB = controlDB;
            model.interacDB = interacDB;
  
            StreamWriter myFile = new StreamWriter("fileName.txt");
            foreach (var prop in model.GetType().GetProperties())
            {
                myFile.WriteLine(prop.Name);
                foreach (var prop1 in model.GetType().GetProperties())
                {
                    if (String.Compare(prop1.Name, prop.Name) == 0)
                    {
                        foreach (int varToSave in (List<int>)prop1.GetValue(model, null))
                        {
                            myFile.WriteLine(varToSave);
                        }
                    }
                }
                
            }
            myFile.Close();
        }
