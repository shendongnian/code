      public IDisposable Use()
      {
         IDisposable r = new ShaderProgram.Handle(curr_program);
         if (curr_program != ID)
         {
            GL.UseProgram(ID);
            curr_program = ID;
         }
         return r;
      }
