    using UnityEngine;
    using System.Collections;
    
    //DONE: abstract: a personage can't be "Vocation", but Mage, Warrior, Archer... 
    public abstract class Vocation
    {
        //DONE: just a readonly property 
        public int Vid {get; }
        //DONE: just a readonly property
        public string Name {get; }
    
        //DONE: let's ensure the property to be overriden
        public abstract HitPointsPerLevel { get; }
    
        //DONE: you don't want this constructor to be public, but protected only   
        //DONE: Assign all the data in one place
        protected Vocation(int vid, string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException("name");
    
            Vid = vid;
            Name = name;
        }
    }
    
    //DONE: do not declare derived class as inner one 
    internal class Mage : Vocation
    {
        sealed public override float HitPointsPerLevel { get { return 12f; } }
    
        //DONE: typo constructor should have been "Mage"
        public Mage() : base(1, "Mage")
        {
        }
    }
