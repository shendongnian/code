    public class HardcodedHashCode {
      private readonly int _hashCode;
    
    	public HardcodedHashCode(int hashCode) { _hashCode = hashCode; }
        
        public override int GetHashCode() => _hashCode;	
    }
    // example test
    public void and_combines_hashcodes_using_xyz_method() {
       var h1 = new HardcodedHashCode(1);
       var h5 = new HardcodedHashCode(5);
       int combinedHashcode = HashCode.of(h1).And(h5);
       
       // sorry but can't force myself to compute manually in the evening
       Assert.Equals(_manually_compute_value_here_, combinedHashcode);
    }
