      public void Save(PlcVariable plcVariable)
        {
            try
            {
                using (var context = new XBSDbDataContext())
                {
                    plcVariable.PlcVariableMeasure.LineObjects // Plc variable has a selfreference that has a list of lineobject, that already has a line object with id = 1
                    var lineobject =  new LineObjectService().GetById(1);//=> this line object is orginated from another Dbcontext.
                    plcVariable.LineObjects.Add(lineobject); 
                    context.SaveChanges(); // error occurs
                    // EF will see the added line object as a different object, because it is coming from another dbcontext, than the same object(equal id's) that is already present.
                }
