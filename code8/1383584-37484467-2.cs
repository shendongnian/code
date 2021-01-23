    // Some entities have different named properties but can be joined
    // using those properties. This interface shows a common color which 
    // when implemented will route the processing to a common shared property
    // which reports and sets the associated color.
    public interface IDefinedColor
    {
        string Color { get; set; }
    }
