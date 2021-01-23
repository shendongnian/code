    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    namespace arrconn {
    	class Program {
    		static string[] conn(params Array[] arrs) {
    			if(arrs.Length == 0) return new string[0];
    			if(arrs.Length == 1) {
    				string[] result = new string[arrs[0].Length];
    				for(int i = 0; i < result.Length; i++)
    					result[i] = arrs[0].GetValue(i).ToString();
    				return result; }
    			else {
    				string[] result = new string[arrs[0].Length*arrs[1].Length];
    				for(int i = 0; i < arrs[0].Length; i++)
    					for(int j = 0; j < arrs[1].Length; j++)
    						result[i*arrs[1].Length+j] = string.Format("{0}_{1}", arrs[0].GetValue(i), arrs[1].GetValue(j));
    				if(arrs.Length == 2) return result;
    				Array[] next = new Array[arrs.Length-1];
    				next[0] = result; Array.Copy(arrs, 2, next, 1, next.Length-1);
    				return conn(next);
    			}
    		}
    		static void Main(string[] args) {
    			foreach(string s in  conn(
    				new string[] { "A", "B" },
    				new int[] { 1, 2, 3 },
    				new string[] { "x" },
    				new string[] { "$", "%", "#" }))
    				Console.WriteLine(s);
    			Console.Read();
    		}
    	}
    }
