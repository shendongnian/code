        [STAThread]
        static void Main(string[] args) {
            try {
                Console.Write("Enter key : ");
                int key = Convert.ToInt32(Console.ReadLine());
                Console.Write("Would you like to [E]ncrypt or [D]ecrypt? : ");
                string choice = Console.ReadLine().ToUpper();
                // Making the decision of writing the filepath or selecting the filepath.
                Console.Write("Would you like to [W]rite or [S]elect the file path? : ");
                string fileChoice = Console.ReadLine().ToUpper();
                string filePath = "";
                if(fileChoice == "W") {
                    Console.WriteLine("Type the filepath the .txt file with your Cipher/Plain text");
                    filePath = Console.ReadLine();
                }
                else {
                    OpenFileDialog dial = new OpenFileDialog();
                    dial.Filter = "Text files (*.txt)|*.txt";
                    if (dial.ShowDialog() == DialogResult.OK)
                        filePath = dial.FileName;
                }
                string stringData;
                using (var reader = new StreamReader(filePath))
                    stringData = reader.ReadToEnd();
                switch (choice) {
                    case "E":
                        caesar_cipher(key, stringData);
                        break;
                    case "D":
                        caesar_decipher(key, stringData);
                        break;
                    default:
                        Console.WriteLine("You've entered an incorrect option!");
                        break;
                }
                Console.ReadLine();  // Added this to make sure you can read the end result.
            }
            catch (Exception) {
                Console.WriteLine("The value you entered is incorrect");
                Console.WriteLine("Press any key to try again");
                Console.ReadKey();
                Main(null); // This will call the main method allowing you to "try again".
            }
        }
