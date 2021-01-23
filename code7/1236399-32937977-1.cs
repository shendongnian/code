    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Drawing;
    namespace WindowsFormsApplication1
    {
        public class Mesh
        {
            static List<Mesh> meshes { get; set; }
            static List<PolyGon> polygons { get; set; }
        }
        public class PolyGon
        {
            List<Edge> edges { get; set; } 
        }
        public class Edge
        {
            List<PointF> points { get; set; }  //two points
            List<PolyGon> parents { get; set; } // two parents
        }
    }
    ​
