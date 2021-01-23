<b>WagenPark wagenPark = new WagenPark(); // put it here</b>
do
{
    int caseSwitch = 1;
    <strike>WagenPark wagenPark = new WagenPark();</strike> // delete this
    Console.WriteLine("*** Wagenpark beheer ***");
    Console.WriteLine("1. Voeg een wagen toe");
    Console.WriteLine("2. Geef wagenpark overzicht");
    caseSwitch = int.Parse(Console.ReadLine());
