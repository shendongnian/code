    using UnityEngine;
    using System.Collections.Generic;
    public class Achievements: MonoBehaviour {
        public  List<Achiv> achivList = new List<Achiv>();
        void Start () {
            achivList.Add (new Achiv("First name", "Descirptionn", false));
            achivList.Add (new Achiv("Second name", "Descirptionnn", false));
            printAchiv();
        }
        void printAchiv(){
            for (int i = 0; i <= achivList.Count - 1; i++)
            {
                Debug.Log("Achiv "+i+": "+ achivList[i].getName());
            }
        }   
    }
