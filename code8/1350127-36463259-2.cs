    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace Test
    {
        class Program
        {
            
            
    
            static void Main(string[] args)
            {
                string person = "Sanders, Bernie     M          Democrat\nBoehner,  John    M  Republican";
                var stripchars = new Regex(@"\s+");
                person = stripchars.Replace(person, " ");
                string[] cell = person.Split('\n'); // spit on each new line
                // temp vars to hold key pieces of information
                string firstname = "";
                string lastname = "";
                string sex = "";
                string party = "";
                string formatted = "";
    
                
                
                // the new line string
                for (int i = 0; i < cell.Length; i++ )
                {
    
                    string[] tempCells = cell[i].Split(' ');
                    //each cell in the line
                    for (int k = 0; k < tempCells.Length; k++)
                    {
                        Console.WriteLine(tempCells[k]);
                        firstname = tempCells[0].Replace(",", "");
                        lastname = tempCells[1];
                        sex = tempCells[2];
                        party = tempCells[3];
                    }
                    string malefemale;
                    if (sex == "M")
                    {
                        malefemale = "Mr.";
                    }
                    else
                        malefemale = "Ms.";
                    formatted = "Dear " + malefemale + " " + lastname + " " + firstname + ":";
    
                    Console.WriteLine(formatted);
                }
                Console.Read();//pause
            }
        }
    
    }
