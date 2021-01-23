    public class Tijdschrift {
    	public DateTime Datum {get;set;}
    	public string Id {get;set;}
    	public string Titel {get;set;}
    	public string Uitgeverij {get;set;}
    	
    	public Tijdschrift(){}
    	
    	public Tijdschrift(string Id, string titel, DateTime datum, string uitgeverij)
    	{
    		Datum = datum;
    		this.Id = Id;
    		Titel = titel;
    		Uitgeverij = uitgeverij;
    	}
    }
