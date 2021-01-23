    class Patient : IComparable { 
      ...
      // Simplest, not thread safe
      private static HashSet<int> s_AllocatedPatientNumbers = new HashSet<int>();
    
      public static Boolean IsNumberAllocated(int patientNumber) {
        return s_AllocatedPatientNumbers.Contains(patientNumber);
      } 
      
      public int PatientNumber { 
        get { 
          return patientNumber; 
        }
        set { 
          s_AllocatedPatientNumbers.Remove(patientNumber);
          patientNumber = value; 
          s_AllocatedPatientNumbers.Add(patientNumber);
        }
      }
    }
