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
                //extra spaces everywhere
                string person = "Sanders, Bernie     M       Democrat\nBoehner,  John    M  Republican";
                var stripchars = new Regex(@"\s+");
                person = stripchars.Replace(person, " ");
                string[] line = person.Split('\n'); // spit on each new line
                // temp vars to hold key pieces of information
                string firstname = "";
                string lastname = "";
                string sex = "";
                string party = "";
                string formatted = "";
    
                // the new line string
                for (int i = 0; i < line.Length; i++ )
                {
    
                    string[] tempCells = line[i].Split(' ');
                    //each cell in the line
                    for (int k = 0; k < tempCells.Length; k++)
                    {
                        firstname = tempCells[0].Replace(",", "");
                        lastname = tempCells[1];
                        sex = tempCells[2];
                        party = tempCells[3];
                    }
                    //updated to use tunrary
                    string malefemale = sex == "M" ? "Mr." : "Ms.";
                    formatted = "Dear " + malefemale + " " + lastname + " " + firstname + ":";
    
                    Console.WriteLine(formatted);
                }
                Console.Read();//pause
            }
        }
    
    }
