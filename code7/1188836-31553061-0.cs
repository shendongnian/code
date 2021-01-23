    public override int GetHashCode()
    {
      return string.Format("DoctorModel{0}", this.ID.ToString()).GetHashCode();
    }
    public override bool Equals(object obj)
    {
       var newObj = obj as DoctorModel;
       if (null != newObj)
       {
           return this.GetHashCode() == newObj.GetHashCode();
       }
       else
       {
           return base.Equals(obj);
       }
    }
