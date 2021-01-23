     public void DisplayVertices(List<Vertex>vertexList)
        {
            String displayText = string.Empty;
            int x, y, z, id;
            foreach(Vertex vertexDetails in vertexList)
            {
                x = vertexDetails.X;
                y = vertexDetails.Y;
                z = vertexDetails.Z;
                id = vertexDetails.VertexID;
                displayText += string.Join(Environment.NewLine, " ID: " + id + " x: " + x + " y: " + y + " z: " + z);
            }
            txtVertexDisplay.Text = displayText;
        }
