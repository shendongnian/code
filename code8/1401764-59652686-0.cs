        public List<Mesh> solidSubtract(ref Mesh meshA, ref Mesh meshB)
        {
          List<Mesh> subtractedMeshes = new List<Mesh>();
          Solid solidA = meshA.ConvertToSolid();
          Solid solidB = meshB.ConvertToSolid();
          Solid[] difference = Solid.Difference(solidA, solidB);
          foreach (Solid sld in difference)
          {
            subtractedMeshes.Add(sld.ConvertToMesh());
          }
          return subtractedMeshes;
        }
