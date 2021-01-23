     public override void EvaluatePolicyDetails(AbsPerson person)
     {
        //I am trying to tally the value given wether the cars worth lies within the range      
        if (this.ValueRange.ContainsKey(new Range<int>() { Maximum = person.APolicy.PropValue, Minimum = person.APolicy.PropValue }))
        {
            this.Tally =
        }
        Console.WriteLine("good");            
    }
