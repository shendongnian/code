    public class MyEnumerator : IEnumerator
            {
                List<ServicesViewModel> lst = new List<ServicesViewModel>();
                int CurrentLocation = -1;
    
                public MyEnumerator(List<ServicesViewModel> p) {
                    this.lst = p;
                }
    
    
                public object Current
                {
                    get
                    {
                        return this.lst[CurrentLocation];
                    }
                }
    
                public bool MoveNext()
                {
                    CurrentLocation++;
                    return (CurrentLocation < this.lst.Count);
                }
    
                public void Reset()
                {
                    CurrentLocation = -1;
                }
            }
