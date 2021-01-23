    public static String month_name(int month) {
            String result;
            result = "a";
            // for the sake of readability I have split the line
            String[] allMonths = { 
                                  "N/A", "January", "February", "March", "April",
                                  "May", "June", "July", "August", "September", 
                                  "October", "November", "December" 
                              };
            if (month >= 0 && month <= 12)
                result = allMonths[month];
            else
               result = "N/A";
            return result;
        }
        static void Main(string[] args) {
            Console.WriteLine("Month 1: " + month_name(1));
            Console.WriteLine("Month 2: " + month_name(2));
            Console.WriteLine("Month 3: " + month_name(3));
            Console.WriteLine("Month 4: " + month_name(4));
            Console.WriteLine("Month 5: " + month_name(5));
            Console.WriteLine("Month 6: " + month_name(6));
            Console.WriteLine("Month 7: " + month_name(7));
            Console.WriteLine("Month 8: " + month_name(8));
            Console.WriteLine("Month 9: " + month_name(9));
            Console.WriteLine("Month 10: " + month_name(10));
            Console.WriteLine("Month 11: " + month_name(11));
            Console.WriteLine("Month 12: " + month_name(12));
            Console.WriteLine("Month 43: " + month_name(43));
            Console.ReadKey();
        }
