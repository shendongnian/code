    [System.Serializable] // this makes it viewable in the inspector
    public struct Sprite_Manager;
    {  
        
        public Sprite[] Render_Sprites; // array of sprites to store sprites
        public SpriteRenderer S_Renderer;
        public float Anim_Delay;
    }
    public class Character : MonoBehavior {
              
      Sprite_Manager SMG = new Sprite_Manager(); // instantiate a new instance of the struct                                                                          
  
          void Set_Sprite()
           {
                 for(int i = 0; i < SMG.Render_Sprites.Length; i++)
                  {
                         SMG.S_Renderer.sprite = SMG.Render_Sprites[i];
                  }
                       
              
           }
          
          void Update
          {
             
             Invoke("Set_Sprite", SMG.Anim_Delay);
          }
        
    }
