    public class state_t
    {
        Unit32 m_elapsedTime;
        SDL_Surface * m_surface;
        void *m_data;
        public void init()
        {
           // Initialise all variables of class
        }
        public void update(UInt32 ElapsedTime)
        {
            m_elapsedTime = ElapsedTime;
        }
        public void handleEvent()
        {
           // Code for Handle Event
        }
        public void draw(SDL_Surface Surface)
        {
           // Code for Draw
           m_surface = Surface;  // maybe, need to check datatype.
        }
        public void clean()
        {
           // Code for Cleaning
        }
        public void data()
        {
           // Code for filling *data variable
        }
    }
