    using System;
    using System.Text.RegularExpressions;
     
    class Program
    {
        static void Main()
        {
        	// This is the input string we are replacing parts from.
        	string input = "select id, :DATA_INI, ':DATA_INI', titulo, "
                    + "date_format(data_criacao,'%d/%m/%Y %H:%i') str_data_criacao\n"
                    + "from v$sugestoes\n"
                    + "where data_criacao between :DATA_INI AND :DATA_FIM\n"
                    + "order by data_criacao";
         
        	string output = 
                Regex.Replace(input, "(((\\\\.|[^':\\\\])('(\\\\.|[^'\\\\])*')?)*):", "$1@");
         
        	Console.WriteLine(output);
        }
    }
