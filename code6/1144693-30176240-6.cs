    public static IEnumerable<int> AllIndexesOf(this string str, string searchText)
    {
      Test.<AllIndexesOf>d__0 allIndexesOfD0 = new Test.<AllIndexesOf>d__0(-2);
      allIndexesOfD0.<>3__str = str;
      allIndexesOfD0.<>3__searchText = searchText;
      return (IEnumerable<int>) allIndexesOfD0;
    }
    [CompilerGenerated]
    private sealed class <AllIndexesOf>d__0 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
    {
      private int <>2__current;
      private int <>1__state;
      private int <>l__initialThreadId;
      public string str;
      public string <>3__str;
      public string searchText;
      public string <>3__searchText;
      public int <index>5__1;
      int IEnumerator<int>.Current
      {
        [DebuggerHidden] get
        {
          return this.<>2__current;
        }
      }
      object IEnumerator.Current
      {
        [DebuggerHidden] get
        {
          return (object) this.<>2__current;
        }
      }
      [DebuggerHidden]
      public <AllIndexesOf>d__0(int <>1__state)
      {
        base..ctor();
        this.<>1__state = param0;
        this.<>l__initialThreadId = Environment.CurrentManagedThreadId;
      }
      [DebuggerHidden]
      IEnumerator<int> IEnumerable<int>.GetEnumerator()
      {
        Test.<AllIndexesOf>d__0 allIndexesOfD0;
        if (Environment.CurrentManagedThreadId == this.<>l__initialThreadId && this.<>1__state == -2)
        {
          this.<>1__state = 0;
          allIndexesOfD0 = this;
        }
        else
          allIndexesOfD0 = new Test.<AllIndexesOf>d__0(0);
        allIndexesOfD0.str = this.<>3__str;
        allIndexesOfD0.searchText = this.<>3__searchText;
        return (IEnumerator<int>) allIndexesOfD0;
      }
      [DebuggerHidden]
      IEnumerator IEnumerable.GetEnumerator()
      {
        return (IEnumerator) this.System.Collections.Generic.IEnumerable<System.Int32>.GetEnumerator();
      }
      bool IEnumerator.MoveNext()
      {
        switch (this.<>1__state)
        {
          case 0:
            this.<>1__state = -1;
            if (this.searchText == null)
              throw new ArgumentNullException("searchText");
            this.<index>5__1 = 0;
            break;
          case 1:
            this.<>1__state = -1;
            this.<index>5__1 += this.searchText.Length;
            break;
          default:
            return false;
        }
        this.<index>5__1 = this.str.IndexOf(this.searchText, this.<index>5__1);
        if (this.<index>5__1 != -1)
        {
          this.<>2__current = this.<index>5__1;
          this.<>1__state = 1;
          return true;
        }
        goto default;
      }
      [DebuggerHidden]
      void IEnumerator.Reset()
      {
        throw new NotSupportedException();
      }
      void IDisposable.Dispose()
      {
      }
    }
