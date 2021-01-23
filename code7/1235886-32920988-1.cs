        Dictionary<string,Tuple<string,Action>> Choices = new Dictionary<string, Tuple<string, Action>>();
        int assholeFactor = 0;
        int niceFactor    = 0;
        int judgement     = 0;
        Choices.Add("rudely" , new Tuple<string, Action>("You're damn right it w.."          , () => assholeFactor++ ));
        Choices.Add("nicely" , new Tuple<string, Action>("No, it wasn't silly. I ca.."       , () => niceFactor++    )); 
        Choices.Add("silence", new Tuple<string, Action>("You sip your wine and say nothing.", () => judgement--     ));
        do
        {          
            string option = Console.ReadLine();
            if (Choices.ContainsKey(option))
            {
                Console.Out.WriteLine(Choices[option].Item1);
                Choices[option].Item2();                    
                break;
            }
            Console.WriteLine("That wasn't an option.");
        } while (true);
