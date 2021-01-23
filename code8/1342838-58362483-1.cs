    using System;
    using Newtonsoft.Json;
    using UnityEngine;
    
    public class NewBehaviourScript : MonoBehaviour
    {
    
        [Serializable]
        public class Person
        {
            public string id;
            public string name;
        }
        public Person[] person;
    
        private void Start()
        {
            var myjson = JsonHelper.ToJson(person);
    
            print(myjson);
    
        }
    }
