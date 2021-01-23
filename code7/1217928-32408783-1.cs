    public override bool Equals(BaseStaff staff) {
      bool baseEquals = base.Equals(staff);
      bool basicStaffEquals = this.BasicStaff.Equals(staff);
      return baseEquals || basicStaffEquals;    
    }
