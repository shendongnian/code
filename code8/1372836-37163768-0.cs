    public static class Handy
       {
       public static float Say(this GameObject go)
          {
          Debug.Log(go.name + ", position is ... "
                 + go.transform.position.ToString("f3");
          }
