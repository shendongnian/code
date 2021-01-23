    Public ToDelimitedString()
    {
        StringBuilder result = new StringBuilder();
        result.Append(String.Format("{0}|{1}|{2}", this.Make, this.Model, this.Year);
        return result.ToString();
    }
    foreach(Car c in cars)
    {
        writer.WriteLine(c.ToDelimitedString());
    }
