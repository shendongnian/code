    private void btnSave_Click(object sender, EventArgs e)
    {
        Member member = new Member();
        member.Name = txtName.Text;
        using (ThreadScopedLifestyle.BeginScope(container)) 
        {
            var memberService = container.GetInstance<IMemberService>();
            memberService.Save(member);
        }
    }
