    using IdxPointList= System.Collections.Generic.List<_3D.Helpers.slicingHelper.Pair<uint, MIRIA.Utility.Vector2D>>;
        
        public class PointHash
                    {
                        struct Impl
                        {
                            Dictionary<uint, IdxPointList> points;
                        }
                        Impl impl;
                        public PointHash()
                        {
                            impl = new Impl();
                        }                    
            }
