    using UnityEngine;
    using System.Collections.Generic;
    
    public class RandomList : MonoBehaviour {
    
      public List <int> originals = new List<int>();
      public List <int> randomized = new List<int>();
      public int desiredNumberOfRandomInts = 5;
    	// Use this for initialization
    	void Awake () {
        for(int i = 1; i <= 20; ++i) {
          originals.Add(i);
        }
        while(randomized.Count < desiredNumberOfRandomInts) {
          int randomSelection = originals[Random.Range(0, originals.Count-1)];
          if (!randomized.Contains(randomSelection)) {
            randomized.Add(randomSelection);
          }
        }
      }
    }
