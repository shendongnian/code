        using System;
        using System.Collections.Generic;
        using System.Linq;    					
        
        public class Movement
        {
        	public int movX {get; set;}
        	public int movY {get; set;}    
        }
        
        public class Program
        {
        	public static void Main()
        	{
            
        		List<Movement> lstMovement = new List<Movement>();	   
        		
        		lstMovement.Add(new Movement() {movX = 1, movY = 3});
        		lstMovement.Add(new Movement() {movX = 1, movY = 3});
        		lstMovement.Add(new Movement() {movX = 2, movY = 2});
        		lstMovement.Add(new Movement() {movX = 2, movY = 4});
        		lstMovement.Add(new Movement() {movX = 3, movY = 5});		
        		       
        		var curMovement = lstMovement.FirstOrDefault(item => item.movX == 1 && item.movY == 3);
            
        		Console.WriteLine(curMovement.movX + ", " + curMovement.movY);      
        	
        	}
        }
