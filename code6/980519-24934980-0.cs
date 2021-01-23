    	public class TopMenu {
    		[Key]
    		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    		public int Id { get; set; }				//Iterator
    		public int Parent { get; set; }			//TopMenuItem parent id
    		public bool Group { get; set; }			//If this have another item below
    		public string Descricao { get; set; }	//Text to show
    		public string Action { get; set; }		//Action to Go
    		public string Controller { get; set; }	//Controller to Go
    	}
