    private void PerformMovement()
    {
    if (Input.GetKeyDown(KeyCode.W))
      m_rb.AddForce(new Vector2(0, m_speed * Time.deltaTime));
    }
    private void CancelFunction()
    {
    if (Input.GetKeyUp(KeyCode.W))  
      m_rb.velocity = 0;
    }
