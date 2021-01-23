    // using this to select entities
    if (Input.GetMouseButtonDown(0) && Camera.main.name == "top_Camera")
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, raycast_length) && hit.collider.gameObject.tag == "npc_entity")
        {
            selected_target = hit.collider.gameObject;
            Debug.Log(selected_target.name + " " + selected_target.GetComponent<AIPlayer>().connected_player.playername);
            UpdateNPCUI();
        }
    }
