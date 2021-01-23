    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using BTWCheck.eu.europa.ec;    
    
    namespace BTWCheck
    {
         class Program
        {
            static void Main(string[] args)
            {
                // VS 2017
                // add service reference -> button "Advanced" -> button "Add Web Reference" ->
                // URL = http://ec.europa.eu/taxation_customs/vies/checkVatService.wsdl 
    
                string Landcode = "NL";
                string BTWNummer = "820471616B01"; // VAT nr BOL.COM 
    
                checkVatService test = new checkVatService();
                test.checkVat(ref Landcode, ref BTWNummer, out bool GeldigBTWNr, out string Naam, out string Adres);
    
                Console.WriteLine(Landcode + BTWNummer + " " + GeldigBTWNr);
                Console.WriteLine(Naam+Adres);
                Console.ReadKey();
    
            }
        }
    }
