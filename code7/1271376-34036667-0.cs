    public enum Prioritas {
      SANGAT_RENDAH = 1, // Technically, assignments are not necessary here and below
      RENDAH = 2,
      SEDANG = 3,
      TINGGI = 4,
      SANGAT_TINGGI = 5,
    }
     
    public static class PrioritasExtensions {
      // technically you don't want it, since you can cast to int
      public static int getValue(this Prioritas value) {
        return (int) value;
      }
    }
....
    Prioritas priority = Prioritas.SEDANG;
    int value = priority.getValue(); // 3 
