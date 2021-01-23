    //1) I want this class to be able to hold not just a true/false status, but a generic type T, so that it can return more data...
    //2) If on the way it's possible to write it in a way that it would run faster and/or facilitate easier data entry.
    class Program {
        static void Main(string[] args) {
            TimeSpan t1 = new TimeSpan(8, 48, 0);
            TimeSpan t2 = new TimeSpan(9, 56, 0);
            TimeSpan t3 = new TimeSpan(10, 5, 0);
            TimeSpan t4 = new TimeSpan(13, 30, 0);
            TO<bool> TO = new TO<bool>(t1, true) {
                new TO<bool>(t2, false) {
                    new TO<bool> (t3, true) {
                        new TO<bool>(t4, false)
                    }
                }
            };
            Console.WriteLine("The time now is considered " + TO.OkNok(DateTime.Now));
            Console.ReadLine();
        }
    }
    public class TO<T> : IEnumerable<TO<T>> {
        public TimeSpan Ti;
        public T Ok;
        public TO<T> NT;
        public TO(TimeSpan timeSpan, T ok) {
            this.Ti = timeSpan;
            this.Ok = ok;
        }
        public T OkNok(DateTime Time) {
            return OkNok(Time.TimeOfDay);
        }
        public T OkNok(TimeSpan currentTime) {
            if(NT == null) {
                return Ok;
            }
            if(currentTime > Ti && currentTime <= NT.Ti) {
                return Ok;
            }
            return NT.OkNok(currentTime);
        }
        public void Add(TO<T> nt) {
            this.NT = nt;
        }
        IEnumerator<TO<T>> IEnumerable<TO<T>>.GetEnumerator() {
            yield return this;
            if(NT != null) {
                yield return NT;
            }
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() {
            yield return this;
            if(NT != null) {
                yield return NT;
            }
        }
    }
