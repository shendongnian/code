    class EnzymeSequence
    {
        public string Name {get;set;}
        public string[] Enzymes {get;set;}
        
        public EnzymeSequence(string name,string[] enzymes)
        {
            Name=name;
            Enzymes=enzymes;
        }
    }
