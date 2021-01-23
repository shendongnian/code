      [DebuggerHidden]
      public override string ToString()
      {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("{ Text = ");
        stringBuilder.Append((object) this.\u003CText\u003Ei__Field);
        stringBuilder.Append(", Value = ");
        stringBuilder.Append((object) this.\u003CValue\u003Ei__Field);
        stringBuilder.Append(" }");
        return ((object) stringBuilder).ToString();
      }
    
      [DebuggerHidden]
      public override bool Equals(object value)
      {
        var fAnonymousType0 = value as \u003C\u003Ef__AnonymousType0<\u003CText\u003Ej__TPar, \u003CValue\u003Ej__TPar>;
        return fAnonymousType0 != null && EqualityComparer<\u003CText\u003Ej__TPar>.Default.Equals(this.\u003CText\u003Ei__Field, fAnonymousType0.\u003CText\u003Ei__Field) && EqualityComparer<\u003CValue\u003Ej__TPar>.Default.Equals(this.\u003CValue\u003Ei__Field, fAnonymousType0.\u003CValue\u003Ei__Field);
      }
    
      [DebuggerHidden]
      public override int GetHashCode()
      {
        return -1521134295 * (-1521134295 * 512982588 + EqualityComparer<\u003CText\u003Ej__TPar>.Default.GetHashCode(this.\u003CText\u003Ei__Field)) + EqualityComparer<\u003CValue\u003Ej__TPar>.Default.GetHashCode(this.\u003CValue\u003Ei__Field);
      }
