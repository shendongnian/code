       public AttachToDoor amazaingDoorScript; ...
       Invoke("test",Random.Range(5f,10f)); ...
       private void test()
         {
         // have a ghost mess with the door occasionally
         amazaingDoorScript.OpenCloseDoor();
         Invoke("test",Random.Range(5f,10f));
         }
