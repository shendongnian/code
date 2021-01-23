    namespace heliBoatMissions
    {
        public class Radar
        {
            public object BlipSprite { get; private set; }
            void Marker()
            {
                var v = new Blip(new Vector3(-699.4645f, -1448.289f, 5.000523f));
                v.Sprite = BlipSprite.Helicopter;
            }
        }
    }
