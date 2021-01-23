    public static IEnumerable<int> AllIndexesOf(this string str, string searchText)
    {
      Test.\u003CAllIndexesOf\u003Ed__0 allIndexesOfD0 = new Test.\u003CAllIndexesOf\u003Ed__0(-2);
      allIndexesOfD0.\u003C\u003E3__str = str;
      allIndexesOfD0.\u003C\u003E3__searchText = searchText;
      return (IEnumerable<int>) allIndexesOfD0;
    }
    [CompilerGenerated]
    private sealed class \u003CAllIndexesOf\u003Ed__0 : IEnumerable<int>, IEnumerable, IEnumerator<int>, IEnumerator, IDisposable
    {
      private int \u003C\u003E2__current;
      private int \u003C\u003E1__state;
      private int \u003C\u003El__initialThreadId;
      public string str;
      public string \u003C\u003E3__str;
      public string searchText;
      public string \u003C\u003E3__searchText;
      public int \u003Cindex\u003E5__1;
      int IEnumerator<int>.Current
      {
        [DebuggerHidden] get
        {
          return this.\u003C\u003E2__current;
        }
      }
      object IEnumerator.Current
      {
        [DebuggerHidden] get
        {
          return (object) this.\u003C\u003E2__current;
        }
      }
      [DebuggerHidden]
      public \u003CAllIndexesOf\u003Ed__0(int \u003C\u003E1__state)
      {
        base.\u002Ector();
        this.\u003C\u003E1__state = param0;
        this.\u003C\u003El__initialThreadId = Environment.CurrentManagedThreadId;
      }
      [DebuggerHidden]
      IEnumerator<int> IEnumerable<int>.GetEnumerator()
      {
        Test.\u003CAllIndexesOf\u003Ed__0 allIndexesOfD0;
        if (Environment.CurrentManagedThreadId == this.\u003C\u003El__initialThreadId && this.\u003C\u003E1__state == -2)
        {
          this.\u003C\u003E1__state = 0;
          allIndexesOfD0 = this;
        }
        else
          allIndexesOfD0 = new Test.\u003CAllIndexesOf\u003Ed__0(0);
        allIndexesOfD0.str = this.\u003C\u003E3__str;
        allIndexesOfD0.searchText = this.\u003C\u003E3__searchText;
        return (IEnumerator<int>) allIndexesOfD0;
      }
      [DebuggerHidden]
      IEnumerator IEnumerable.GetEnumerator()
      {
        return (IEnumerator) this.System\u002ECollections\u002EGeneric\u002EIEnumerable\u003CSystem\u002EInt32\u003E\u002EGetEnumerator();
      }
      bool IEnumerator.MoveNext()
      {
        switch (this.\u003C\u003E1__state)
        {
          case 0:
            this.\u003C\u003E1__state = -1;
            if (this.searchText == null)
              throw new ArgumentNullException("searchText");
            this.\u003Cindex\u003E5__1 = 0;
            break;
          case 1:
            this.\u003C\u003E1__state = -1;
            this.\u003Cindex\u003E5__1 += this.searchText.Length;
            break;
          default:
            return false;
        }
        this.\u003Cindex\u003E5__1 = this.str.IndexOf(this.searchText, this.\u003Cindex\u003E5__1);
        if (this.\u003Cindex\u003E5__1 != -1)
        {
          this.\u003C\u003E2__current = this.\u003Cindex\u003E5__1;
          this.\u003C\u003E1__state = 1;
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
  }
