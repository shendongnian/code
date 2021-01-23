    for (int c1Index = 0; c1Index < RigidBodies.Count; c1Index++)
     {
          for (int c2Index = c1Index + 1; c2Index < RigidBodies.Count; c2Index++)
          {
               HandleCollisions(RigidBodies[c1Index], RigidBodies[c2Index]);
          }
     }
