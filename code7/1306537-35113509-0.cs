    using UnityEngine;
    using System.Collections.Generic;
    
    public class People {
        public string name;
        public int type;
    }
    
    public class Game {
        public List<People> people;
    
        public void Start() {
            People p = new People();
            p.name = "Vitor";
            p.type = 1;
    
            people = new List<People>();
            people.Add(p);
    
            Debug.Log(p[0].name);
        }
    }
