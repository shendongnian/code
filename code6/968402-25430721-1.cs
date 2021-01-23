    public void Put([FromUri] int Del, [FromBody]string vardata)
    {
        Variables vari = JsonConvert.DeserializeObject<Variables>(vardata.Substring(1, vardata.Length-2));
        var Item = (from c in TMIRE.Variables
                    where c.VariableID == vari.VariableID
                    select c).First();
        if (Del == 0)
        {
            Item.VariableDateUpdated = DateTime.Now;
            Item.VariableName = vari.VariableName;
            Item.VariableDescription = vari.VariableDescription;
            Item.VariableValue = vari.VariableValue;
            Item.VariableType = vari.VariableType;
        }
        else
        {
            Item.VariableDateUpdated = DateTime.Now;
            Item.VariableActive = false;
        }
        TMIRE.SaveChanges();
    }
