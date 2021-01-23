	public class Rootobject
	{
		public string status { get; set; }
		public string status_message { get; set; }
		public Data data { get; set; }
		public Meta meta { get; set; }
	}
	public class Data
	{
		public int movie_count { get; set; }
		public int limit { get; set; }
		public int page_number { get; set; }
		public Movie[] movies { get; set; }
	}
	public class Movie
	{
		public int id { get; set; }
		public string url { get; set; }
		public string imdb_code { get; set; }
		public string title { get; set; }
		public string title_english { get; set; }
		public string title_long { get; set; }
		public string slug { get; set; }
		public int year { get; set; }
		public float rating { get; set; }
		public int runtime { get; set; }
		public string[] genres { get; set; }
		public string summary { get; set; }
		public string description_full { get; set; }
		public string synopsis { get; set; }
		public string yt_trailer_code { get; set; }
		public string language { get; set; }
		public string mpa_rating { get; set; }
		public string background_image { get; set; }
		public string background_image_original { get; set; }
		public string small_cover_image { get; set; }
		public string medium_cover_image { get; set; }
		public string large_cover_image { get; set; }
		public string state { get; set; }
		public Torrent[] torrents { get; set; }
		public string date_uploaded { get; set; }
		public int date_uploaded_unix { get; set; }
	}
	public class Torrent
	{
		public string url { get; set; }
		public string hash { get; set; }
		public string quality { get; set; }
		public int seeds { get; set; }
		public int peers { get; set; }
		public string size { get; set; }
		public int size_bytes { get; set; }
		public string date_uploaded { get; set; }
		public int date_uploaded_unix { get; set; }
	}
	public class Meta
	{
		public int server_time { get; set; }
		public string server_timezone { get; set; }
		public int api_version { get; set; }
		public string execution_time { get; set; }
	}
