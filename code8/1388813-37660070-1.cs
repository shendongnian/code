     public struct myOwnStruct : IEnumerator
        {
          IEnumerator.Current { get{/* implementation*/}}
          void IEnumerator.Reset(){}
          bool IEnumerator.MoveNext(){return true;}
        }
