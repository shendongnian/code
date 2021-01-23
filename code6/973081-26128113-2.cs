    using System;
    using System.Collections.Generic;
    class Solution {
        public int solution(int[] A) {
        
            // the minimum possible answer is 1
            int result = 1; 
            // let's keep track of what we find
            Dictionary<int,bool> found = new Dictionary<int,bool>();
            
            // loop through the given array  
            for(int i=0;i<A.Length;i++) {
                // if we have a positive integer that we haven't found before
                if(A[i] > 0 && !found.ContainsKey(A[i])) {
                    // record the fact that we found it
                    found.Add(A[i], true);
                }
            }
        
            // crawl through what we found starting at 1
            while(found.ContainsKey(result)) {
                // look for the next number
                result++;
            }
 
            // return the smallest positive number that we couldn't find.
            return result;
        }
    }
