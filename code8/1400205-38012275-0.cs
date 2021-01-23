    Console.WriteLine("Enter the overall count of students.");
    
            int stuCount = Convert.ToInt32(Console.ReadLine());         
    
    		List<Grade> allGrades = new List<Grade>();
    
            for (int i = 0; i < stuCount; i++)
            {
                Console.WriteLine("Enter the name of student # {0}.", i + 1);
                var name = Console.ReadLine();
                Console.WriteLine("Enter the average grade of {0}.", name[i]);
                var avg = Convert.ToDouble(Console.ReadLine());
    			Grade current = new Grade(){
    				Name = name, 
    				Average = avg
    			};
    			allGrades.Add(current);
            }
    
            // Finding the max average
            double maxAvg = allGrades.Max(g => g.Average);
    		var highestGrades = allGrades.Where(g => g.Average == maxAvg);
    
    		Console.WriteLine("The following Student(s) have the highest average grade:");
    		foreach(var grade in highestGrades){
    		        // Displaying the max average
            		Console.WriteLine("Student: {0}. Grade: {1}.", grade.Name, grade.Average);
    		}
    }
