    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Xml.Serialization;
    /// <summary>
    /// Summary description for GameXML
    /// </summary>
    [XmlRoot("gameset")]
    public class GameSet
    {
    [XmlElement("game")]
    public List<Game> Game { get; set; }
    }
    [XmlRoot("game")]
    public class Game
    {
    [XmlElement("id")]
    public int ID { get; set; }
    [XmlElement("title")]
    public string Title { get; set; }
    [XmlElement("thumbnail")]
    public string Thumbnail { get; set; }
    [XmlElement("launch_date")]
    public string Launch { get; set; }
    [XmlElement("category")]
    public string Category { get; set; }
    [XmlElement("flash_file")]
    public string Flash { get; set; }
    [XmlElement("width")]
    public string Width { get; set; }
    [XmlElement("height")]
    public string Height { get; set; }
    [XmlElement("url")]
    public string Url { get; set; }
    [XmlElement("description")]
    public string Description { get; set; }
    [XmlElement("instructions")]
    public string Instructions { get; set; }
    [XmlElement("developer_name")]
    public string Developer_name{ get; set; }
    [XmlElement("gameplays")]
    public string Gameplays { get; set; }
    [XmlElement("rating")]
    public string Rating { get; set; }
    
    }
