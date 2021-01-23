    [HttpPost]
    public ActionResult Index(MeaningfulName model)
    {             
         using (SqlCommand command = new  SqlCommand("SysDefinitionPopulate", con))
         {
             command.CommandType = CommandType.StoredProcedure;
             command.Parameters.Add("@key", model.First);
             command.Parameters.Add("@value", model.Second);
             command.ExecuteScalar();
         }
    }
