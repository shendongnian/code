    public override bool Equals(object obj) {
        if (obj == null) return false;
        Part objAsNote = obj as MyNote;
        if (objAsNote == null) return false;
        else return Equals(objAsNote);
    }
    
    public bool Equals(MyNote otherNote) {
        if(otherNote == null) return false;
        return (this.ID.Equals(otherNote.ID));
    }
    
    public override int GetHashCode(){
        return this.ID;
    }
