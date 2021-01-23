    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    
    public class test2 : MonoBehaviour {
    
        System.Random rand;
        int[] excludelist;
        void Start()
        {
             rand = new System.Random();
            excludelist = new int[] { 5,9,3};
            for(int i = 0; i<20;i++)
            {
                Debug.Log(MakeMeNumber(excludelist));
            }
            
        }
        private int MakeMeNumber(params int[] excludeList)
        {
            var excluding = new HashSet<int>(excludeList);
            var range = Enumerable.Range(1, 20).Where(i => !excluding.Contains(i));
    
           
            int index = rand.Next(0, 20 - excluding.Count);
            return range.ElementAt(index);
        }
    }
